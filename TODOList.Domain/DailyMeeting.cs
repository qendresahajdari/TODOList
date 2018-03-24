using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public struct DailyMeeteings {
        private int d_koha;
  
        public int koha
        {
            get
            {
                return d_koha;
            }
            set
            {
                d_koha = value;
            }
        }

        private string d_vendi;

        public string vendi
        {
            get
            {
                return d_vendi;
            }
            set
            {
                d_vendi = value;
            }
        }

        public DailyMeeteings(int koha,
            string vendi)
        { d_koha = koha; d_vendi = vendi; }

    }

}
