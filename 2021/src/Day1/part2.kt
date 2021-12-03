package Day1

import Shared.fileAsInts

fun main()
{
    var input = fileAsInts("src/Day1/input.txt")
    var output = input.drop(3)
        .fold(0 to input.take(3)) { counter, it -> (counter.second.drop(1) + it).let { next ->
            (counter.first + (if (next.sum() > counter.second.sum()) 1 else 0) to next)
        }}
    println(output.first)
}