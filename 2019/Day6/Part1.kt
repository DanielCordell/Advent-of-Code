package day6a
import java.io.File

data class Planet(val name: String, val orbits: String?);

val planets = hashMapOf("COM" to Planet("COM", null))
val inputs = File("src/input.txt").readLines().map { it.split(")").toTypedArray() }

fun countOrbits(planet: Planet, count: Int = 0): Int =
    if (planet.name == "COM") count
    else countOrbits(planets[planet.orbits]!!, count + 1)

fun main() {
    inputs.forEach { planets.put(it[1], Planet(it[1], it[0])) }
    print(planets.map { countOrbits(it.value) }.toIntArray().sum());
}