using BattleShipGame.Models;
using BattleShipGame.Services;
using System.Collections;
using Xunit;

namespace BattleShipGame.Tests.Services
{
    public class BoardServiceTest
    {
        private readonly IBoardService _sut;
        public BoardServiceTest() =>
            _sut = new BoardService();

        [Theory]
        [ClassData(typeof(GetNewShipCoordinatesTestData))]
        public void GetNewShipCoordinates_ShouldReturnValidCoordinates(bool expected, Board board)
        {
            var dimention = 10;
            var shipLength = 3;
            var result = _sut.GetNewShipCoordinates(new Board(dimention), shipLength);

            foreach (var coordinate in result)
            {
                Assert.InRange(coordinate.Item1, 0, dimention - 1);
                Assert.InRange(coordinate.Item2, 0, dimention - 1);
                Assert.Equal(0, board.Cells[coordinate.Item1, coordinate.Item2]);
            }
        }

        private class GetNewShipCoordinatesTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var dimention = 10;
                Board board = new Board(dimention);
                board.Cells[3, 2] = 1;
                board.Cells[3, 3] = 1;
                board.Cells[3, 4] = 1;

                yield return new object[]
                {
                    true,
                    board,
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        [Theory]
        [ClassData(typeof(GetHitTestData))]
        public void GetHit_ShouldReturnTrueOnHit(bool expected, Board board, int x, int y)
        {
            var result = _sut.GetHit(board, x, y);
            Assert.Equal(expected, result);
        }

        private class GetHitTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var board = new Board(10);
                board.Cells[3, 2] = 3;
                board.Cells[3, 3] = 3;
                board.Cells[3, 4] = 3;
                board.Fleet.Add(new Ship(new List<(int, int)>()
                {
                    (3,2),
                    (3,3),
                    (3,4)
                }));
                yield return new object[]
                {
                    true,
                    board,
                    3,
                    3
                };
                yield return new object[]
                {
                    true,
                    board,
                    3,
                    2
                };
                yield return new object[]
                {
                    true,
                    board,
                    3,
                    4
                };
                yield return new object[]
                {
                    false,
                    board,
                    3,
                    5
                };
                yield return new object[]
                {
                    false,
                    board,
                    2,
                    3
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void SetShipData_ShouldAddShipToFleetAndMarkBoard() 
        {
            var dimention = 10;
            var shipLength = 4;
            var board = new Board(dimention);
            _sut.SetShip(board,shipLength);

            Assert.True(board.Fleet.Count == 1);
            board.Fleet.ForEach(ship => 
                Assert.True(ship.Compartments.All(c => 
                    board.Cells[c.X, c.Y] == shipLength)));
        }

    }
}
