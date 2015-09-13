using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lsj.Util.IO
{
   public static class DirectoryHelper
   {
      /// <summary>
      /// Get All Files including child directory
      /// </summary>
      public static List<string> GetAllFiles(DirectoryInfo path,string filter)
      {
         var result = new List<string>;
         if(path.Exists)
         {
            result.AddRange(path.GetFiles(filter));
            DirectoryInfo[] directories = path.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
               DirectoryInfo subdir = directories[i];
               result.AddRange(GetAllFiles(subdir, filter));  
            }
         }         
         return result;
      }
   }
}