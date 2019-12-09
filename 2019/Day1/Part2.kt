import java.io.File


fun getFuel(weight: Int): Int {
    (weight / 3 - 2).also { return if (it < 0) 0 else it };
}

fun main() {
    val inputs = ArrayList<Int>().apply {
        File("src/input.txt").forEachLine { this.add(it.toInt()) }
    }
    println(inputs.map {

        getFuel(it);

        var sum = 0;
        var temp = it;
        while (temp > 0) {
            temp = getFuel(temp);
            sum += temp;
        }
        sum
    }.sum())
}

