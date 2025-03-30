using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.File
{
    public class File
    {
        public File()
        {
            
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public File(string name,string path)
        {
            Id= Guid.NewGuid();

            Name= name;

            Path= path;
        }
    }
}
