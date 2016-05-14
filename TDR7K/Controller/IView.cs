using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDR7K.Controller
{
   public interface IView
    {
       void SetController(AppController controller);
       void AddMsgToRichText(string Message);
    }
}
