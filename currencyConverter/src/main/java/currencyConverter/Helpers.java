package currencyConverter;

public class Helpers {

    public static boolean isBetween(float value, int min, int max) {
        return((value > min) && (value < max));
    }
}