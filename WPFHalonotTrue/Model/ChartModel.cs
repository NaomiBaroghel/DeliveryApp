using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.Model
{
    class ChartModel
    {
        private ChartVM chartVM;
        BLImp blimp { get; set; }
        public ChartModel(ChartVM chartVM)
        {
            this.chartVM = chartVM;
            blimp = new BLImp();
        }



        #region day
        //return nb of distribution planned of a certain day and a certain city
        public int DisPlanned(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisPlanned(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution done of a certain day and a certain city
        public int DisDone(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisDone(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution done of a certain city in the day choosen but not planned 
        public int DisNotPlannedButDone(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisNotPlannedButDone(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution canceled of a certain day and a certain city
        public int DisCanceled(DateTime myday, string mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisCanceled(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region week

        //return nb of distribution planned of a certain week and a certain city
        public int DisPlannedWeek(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisPlannedWeek(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution done of a certain weenk and a certain city
        public int DisDoneWeek(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisDoneWeek(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //return nb of distribution done of a certain city in the week choosen but not planned
        public int DisNotPlannedButDoneWeek(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisNotPlannedButDoneWeek(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution canceled of a certain week and a certain city
        public int DisCanceledWeek(DateTime myday, string mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisCanceledWeek(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region month

        //return nb of distribution planned of a certain month and a certain city
        public int DisPlannedMonth(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisPlannedMonth(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution done of a certain month and a certain city
        public int DisDoneMonth(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisDoneMonth(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //return nb of distribution done of a certain city of the month choosen but not planned
        public int DisNotPlannedButDoneMonth(DateTime myday, String mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisNotPlannedButDoneMonth(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return nb of distribution canceled of a certain month and a certain city
        public int DisCanceledMonth(DateTime myday, string mycity)
        {
            try
            {
                List<Distribution> mylist = blimp.DisCanceledMonth(myday, mycity);
                return mylist.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
