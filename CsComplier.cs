using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.IO;

namespace Lsj.Util
{
    /// <summary>
    /// Cs Complier
    /// </summary>
    public class CsComplier
    {
        /// <summary>
        /// Target Dll
        /// </summary>
        public string target = "target.dll";
        /// <summary>
        /// Using DLL
        /// </summary>
        public string[] @using = { "" };
        /// <summary>
        /// Source Path
        /// </summary>
        public string path = Static.CurrentPath();
        ///<summary> 
        /// Error
        /// </summary>    
        public string Error => temp;

        private string error ="";

        /// <summary>
        /// Complie
        /// </summary>
        public bool Complie() => Complie(ref error);
        
        /// <summary>
        /// Complie
        /// <param name="log">log</param>
        /// </summary>
        public bool Complie(ref string log)
        {
            var files = DirectoryHelper.GetAllFiles(new DirectoryInfo(path),"*.cs")
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
                    error = log;
                    result = false;
                    return result;
                }
                result = true;
            }
            log = "Success!";
            return result;
        }
    }
}