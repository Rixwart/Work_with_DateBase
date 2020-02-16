using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWorkApp.View
{
    public static class FormOpener
    {
        public static Form GetForm(this User user)
        {
            switch (user.Rolee)
            {
                case Role.Executor: return new ExecutorForm(); 
                case Role.Manager: return new ManagerForm(); 
                default:throw new Exception("Form Null"); 
            }
        }
    }
}
