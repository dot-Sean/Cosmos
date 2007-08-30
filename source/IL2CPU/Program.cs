﻿using System;
using System.IO;
using System.Linq;
using Indy.IL2CPU;
using Indy.IL2CPU.IL.X86;

namespace IL2CPU {
	public class Program {
		public static void Main(string[] args) {
			try {
				Engine e = new Engine();
				e.DebugLog += delegate(string aMessage) {
					Console.WriteLine(aMessage);
				};
				using (FileStream fs = new FileStream(@"output.asm", FileMode.Create)) {
					using (StreamWriter br = new StreamWriter(fs)) {
						e.Execute("HelloWorld.exe", typeof(Nop).Assembly.GetName().ToString(), br);
					}
				}
			} catch (Exception E) {
				Console.WriteLine(E.ToString());
			}
			Console.WriteLine("");
			Console.WriteLine("Completed");
			Console.ReadLine();
		}
	}
}