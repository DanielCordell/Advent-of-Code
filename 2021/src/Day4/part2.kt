package Day4.Part2

import Shared.fileAsStrings

fun main()
{
    var input = fileAsStrings("src/Day4/input.txt")

    var moves = input[0].split(",".toRegex()).map { Integer.parseInt(it) }
    var boards = input.drop(1).chunked(6).map { it -> it.drop(1).map { itt -> itt.trim().split("  *".toRegex()).map { ittt -> Integer.parseInt(ittt) to false } } }

    for(move in moves)
    {
        var newBoards = permutateBoards(boards, move).map { it to isSolved(it) }
        if (newBoards.size == 1 && newBoards.all { it.second })
        {
            println(calculateScore(newBoards[0].first, move))
            return;
        }
        boards = newBoards.filter { !it.second }.map { it.first }
    }
}

fun calculateScore(board: List<List<Pair<Int, Boolean>>>, move: Int) : Int
{
    return move * (board.fold(0) { score, row -> score + row.fold(0) { rowscore, cell -> rowscore + if (cell.second) 0 else cell.first } })
}

fun permutateBoards(boards: List<List<List<Pair<Int, Boolean>>>>, move: Int): List<List<List<Pair<Int, Boolean>>>> {
    return boards.map { board -> board.map { row -> row.map { cell -> if (cell.first == move) cell.first to true else cell } } }
}


fun isSolved(board: List<List<Pair<Int, Boolean>>>): Boolean {
    return board.any{ it.all { itt -> itt.second } }
            ||
            board.fold(intArrayOf(0,0,0,0,0)) { counts, row -> intArrayOf(
                i(counts, row, 0),
                i(counts, row, 1),
                i(counts, row, 2),
                i(counts, row, 3),
                i(counts, row, 4)

            ) }.any { it == 5 }
}

private fun i(
    counts: IntArray,
    row: List<Pair<Int, Boolean>>,
    index: Int
) = counts[index] + if (row[index].second) 1 else 0