using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.gestapoghost.entertainment.tools
{
    public class Paging
    {

        public Paging(int number)
        {
            ItemNum = number;
            CurrentPage = 1;
            PageItemNum = 50;
            TotalPage = ItemNum / PageItemNum;
            if (ItemNum % PageItemNum > 0)
            {
                TotalPage++;
            }
        }
        public Paging(int number, int itemnum)
        {
            ItemNum = number;
            CurrentPage = 1;
            PageItemNum = itemnum;
            TotalPage = ItemNum / PageItemNum;
            if (ItemNum % PageItemNum > 0)
            {
                TotalPage++;
            }
        }

        public int ItemNum { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageItemNum { get; set; }
        public int GetItemBeforeNum() 
        {
            return (CurrentPage - 1) * PageItemNum;
        }

        public bool cannext() 
        {
            if (CurrentPage < TotalPage)
                return true;
            else
                return false;
        }
        public bool canback() 
        {
            if (CurrentPage > 1)
                return true;
            else
                return false;
        }

        public void next()
        {
            CurrentPage++;
        }
        public void back()
        {
            CurrentPage--;
        }

    }
}
