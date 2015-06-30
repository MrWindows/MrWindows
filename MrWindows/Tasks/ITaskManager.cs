using System.Collections.Generic;
using System.Diagnostics;

namespace Dear.Tasks {
    public interface ITaskManager {
        Process OpenApp(string key);
        Process GoogleThis(string query);
        List<Process> ListAllProcesses();
    }
}