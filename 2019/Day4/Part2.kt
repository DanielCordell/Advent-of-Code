import java.io.File

fun doesPass2(i: Int): Boolean {
    val iString = i.toString();
    return iString.zipWithNext().all { it.first <= it.second } && strSplit(iString).any { it.length == 2 }
}

fun strSplit(str: String): List<String> {
    return ArrayList<String>().also {
        var current: Char? = null
        var substr = ""
        for (c in str) { if (substr == "") { substr = "$c"; current = c } else if (current == c) substr += c else { current = c; it.add(substr); substr = "$c" } }
        it.add(substr)
    }
}

fun main() {
    val inputs = File("src/input.txt").readLines()[0].split("-").map { it.toInt() }

    var count = 0;
    for (i in (inputs[0]..inputs[1])) {
        if (doesPass2(i)) count++
    }
    println(count)
}