using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// cs编译器类
    /// </summary>
    public class CsComplier
    {
        /// <summary>
        /// 目标dll
        /// </summary>
        public string target = "target.dll";
        /// <summary>
        /// 引用dll
        /// </summary>
        public string[] @using = { "" };
        /// <summary>
        /// 源路径
        /// </summary>
        public string path = Static.CurrentPath();

        private string temp;

        /// <summary>
        /// 编译
        /// </summary>
        public bool Complie() => Complie(ref temp);
        /// <summary>
        /// <param name="log">日志</param>
        /// </summary>
        public bool Complie(ref string log)
        {
            ArrayList files = ParseDirectory(new DirectoryInfo(path), "*.cs");
            bool result;
            if (files.Count == 0)
            {
                result = true;
            }
            else
            {
                if (File.Exists(target))
                {
                    File.Delete(target);
                }
                CompilerResults res = null;
                CodeDomProvider compiler = new CSharpCodeProvider();

                CompilerParameters param = new CompilerParameters(@using, target, false);
                param.GenerateExecutable = false;
                param.GenerateInMemory = false;
                param.WarningLevel = 2;
                param.CompilerOptions = "/lib:.";
                string[] filepaths = new string[files.Count];
                for (int i = 0; i < files.Count; i++)
                {
                    filepaths[i] = ((FileInfo)files[i]).FullName;
                }
                res = compiler.CompileAssemblyFromFile(param, filepaths);
                GC.Collect();
                if (res.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CompilerError err in res.Errors)
                    {
                        
                        if (!err.IsWarning)
                        {
                            StringBuilder builder = new StringBuilder();
                            builder.Append("   ");
                            builder.Append(err.FileName);
                            builder.Append(" Line:");
                            builder.Append(err.Line);
                            builder.Append(" Col:");
                            builder.Append(err.Column);
                            sb.Append("Script compilation failed because: "+err.ErrorText+builder.ToString());
                            sb.Append("\r\n");
                        }
                    }
                    log = sb.ToString();
                    result = false;
                    return result;
                }
                result = true;
            }
            log = "Success!";
            return result;
        }
        private ArrayList ParseDirectory(DirectoryInfo path, string filter)
        {
            ArrayList files = new ArrayList();
            ArrayList result;
            if (!path.Exists)
            {
                result = files;
            }
            else
            {
                files.AddRange(path.GetFiles(filter));
                DirectoryInfo[] directories = path.GetDirectories();
                for (int i = 0; i < directories.Length; i++)
                {
                    DirectoryInfo subdir = directories[i];
                    files.AddRange(ParseDirectory(subdir, filter));
                }
                result = files;
            }
            return result;
        }
    }
}
