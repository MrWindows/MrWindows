using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dear.Tasks {
    public class TaskManager : ITaskManager {
        public Process OpenApp(string key) {
            return Process.Start(key);
        }

        public Process GoogleThis(string query) {
            return Process.Start("http://google.com/search?q=" + query);
        }

        public List<Process> ListAllProcesses() {
            return Process.GetProcesses().ToList();
        } 
    }
}