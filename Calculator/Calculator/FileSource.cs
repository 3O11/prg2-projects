using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculator {
    class FileSource : ISource {
        public FileSource(string filename) {
            if(File.Exists(filename))
                fileHandle = new StreamReader(filename);
        }

        public bool HasNext() {
            return !fileHandle.EndOfStream;
        }

        public string GetLine() {
            return fileHandle.ReadLine();
        }

        StreamReader fileHandle;
    }
}
