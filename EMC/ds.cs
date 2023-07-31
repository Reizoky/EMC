namespace EMC
{


    public partial class ds
    {
        partial class pk_trebovaniaDataTable
        {
        }

        partial class trebovaniaDataTable
        {
        }

        partial class literaturaDataTable
        {
        }

        partial class sodDataTable
        {
            public override void EndInit()
            {
                base.EndInit();
                sodRowChanged += new sodRowChangeEventHandler(TestRowChangeEvent);
            }

            public void TestRowChangeEvent(object sender, sodRowChangeEvent e)
            {
                if (e.Row.aud <= 0)
                    e.Row.aud = 2;
                if (e.Row.sam < 0)
                    e.Row.sam = 0;
                if (e.Row.samDop > e.Row.sam)
                    e.Row.samDop = e.Row.sam;
            }
        }

        partial class razdelDataTable
        {
        }
    }
}
