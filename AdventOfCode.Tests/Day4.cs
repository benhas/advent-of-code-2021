using System;
using System.Collections;
using System.Collections.Generic;
using AdventOfCode.Days.Day4;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day4
    {
        
        [Theory]
        [ClassData(typeof())]
        public void CheckRows_bingoCard_rowsChecked()
        {
            
        }
    }

    /*
    public class TestDataGenerator : IEnumerable<BingoCard>
    {
        /*
        private readonly IEnumerable<BingoCard> _data = new BingoCard
        ()
        {
            new List<BingoCell>(){
                //row 0
                new BingoCell(0, 0, 0, false),
                new BingoCell(0, 1, 0, false),
                new BingoCell(0, 2, 0, false),
                new BingoCell(0, 3, 0, false),
                new BingoCell(0, 4, 0, false),
                //row 1
                new BingoCell(0, 0, 0, true),
                new BingoCell(0, 1, 0, false),
                new BingoCell(0, 2, 0, true),
                new BingoCell(0, 3, 0, false),
                new BingoCell(0, 4, 0, false,
                    //row 2
                    new BingoCell(0, 0, 0, true),
                new BingoCell(0, 1, 0, true),
                new BingoCell(0, 2, 0, true),
                new BingoCell(0, 3, 0, true),
                new BingoCell(0, 4, 0, true)
            }
            };

        public IEnumerator<List<BingoCell>> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        */
}