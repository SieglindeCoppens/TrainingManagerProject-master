using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class TrainingContextTest : TrainingContext
    {
        public TrainingContextTest(bool keepExistingDB = false) : base("Test")
        {
            if (keepExistingDB)
            {
                Database.EnsureCreated();
            }
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
