package Shared

import java.io.File

fun fileAsInts(fileName: String): List<Int>
        = File(fileName).useLines { it.map { line -> line.toInt() }.toList() }

fun fileAsStrings(fileName: String): List<String>
        = File(fileName).readLines()


fun fileAsSplitStrings(fileName: String) : List<List<String>>
        = File(fileName).useLines { it.map { line -> line.split(" ") }.toList() }