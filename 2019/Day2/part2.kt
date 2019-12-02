import java.io.File

fun main() {
    val inputs = File("src/input.txt").readLines()[0].split(",").map { it.toInt() }

    for (noun in (0 .. 99)) {
        for (verb in (0 .. 99)) {
            val myinputs = ArrayList<Int>().apply { addAll(inputs) }
            var ip = 0;
            myinputs[1] = noun;
            myinputs[2] = verb;
            while (myinputs[ip] != 99) {
                val opcode = myinputs[ip];
                val in1 = myinputs[myinputs[ip + 1]];
                val in2 = myinputs[myinputs[ip + 2]];
                myinputs[myinputs[ip + 3]] = if (opcode == 1) in1 + in2 else if (opcode == 2) in1 * in2 else -1
                ip += 4;
            }
            if (myinputs[0] == 19690720) {
                println(noun * 100 + verb);
                return;
            }
        }
    }
}