using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Homework4.Model;

namespace Wpf_Homework4.Services
{
    interface IFileService
    {
        List<Friend> LoadFriendsFile(string filename);

        void SaveFriendsFile(string filename, List<Friend> friends);
    }
}
