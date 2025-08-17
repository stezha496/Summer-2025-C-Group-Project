using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_WindowsFormsApp
{
    public interface FileService
    {
        void SaveConfig(string path, Simulation config);
        Simulation LoadConfig(string path);

        void AppendRunLog(string path, int iteration, int humans, int zombies);
    }
}
