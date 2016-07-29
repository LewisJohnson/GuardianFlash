using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;




namespace GuardianFlash
{
    [DelimitedRecord("|")]
    class FlashCard
    {
        public string Front;
        public string Back;
        public Difficulty CardDifficulty;
        public enum Difficulty
        {
            easy,
            medium,
            hard,
            very
        }
        
        public FlashCard()
        {
         
        }

        
    }
}
