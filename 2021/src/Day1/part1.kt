package Day1

import Shared.fileAsInts

fun main()
{
    var input = fileAsInts("src/Day1/input.txt")
    var output = input.drop(1).fold(0 to input[0]) { counter, it -> (counter.first + if (it > counter.second) 1 else 0) to it }
    println(output.first)
}