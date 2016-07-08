﻿using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditorZendesk;

namespace ZendeskSDK {
	public class ZendeskPostProcess : MonoBehaviour {
		
		[PostProcessBuild(-10)]
		public static void OnPostProcessBuildCleanup(BuildTarget target, string path)
		{
			ZDKCleanup.Clean();
		}
		
		[PostProcessBuild(5000)]
		public static void OnPostProcessBuild(BuildTarget target, string path)
		{
			if(target == BuildTarget.iOS) {
				PostProcessBuild_iOS(path);
			}
			else if(target == BuildTarget.Android) {
				PostProcessBuild_Android(path);
			}
		}
		
		private static void PostProcessBuild_iOS(string path)
		{
			ProcessXCodeProject(path);
		}
		
		private static void PostProcessBuild_Android(string path)
		{
			// Check for manifest issues
			if (!ZDKManifest.CheckAndFixManifest())
			{
				// If something is wrong with the Android Manifest, try to regenerate it to fix it for the next build.
				ZDKManifest.GenerateManifest();
			}
		}
		
		private static void ProcessXCodeProject(string path)
		{
			UnityEditor.XCodeEditorZendesk.XCProject project = new UnityEditor.XCodeEditorZendesk.XCProject(path);

			// Find and run through all projmods files to patch the project
			string projModPath = System.IO.Path.Combine(Application.dataPath, "Zendesk/Editor");
			var files = System.IO.Directory.GetFiles(projModPath, "*.projmods", System.IO.SearchOption.AllDirectories);
			foreach (var file in files)
			{
				project.ApplyMod(file);
			}
			project.Save();
		}
	}
}
