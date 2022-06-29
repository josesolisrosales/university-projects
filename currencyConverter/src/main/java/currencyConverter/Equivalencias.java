package currencyConverter;

import java.util.Arrays;

// Clase con los constructores
class constructorClass{

    //Overload de constructor constructorClass
    public constructorClass(int numeroMonedas) {

        if (numeroMonedas >= 5 && numeroMonedas <= 25) {
            defaultDescripcionMonedas = new String[]{
                "dolar estadounidense",
                "euros",
                "colones",
                "pesos mexicanos",
                "cordobas oro",
                "pesos argentinos",
                "libra esterlina",
                "yen"
                };

            defaultValorMonedas = new float[][]{
                {1, 1},
                {0.85f, 0.91f},
                {660, 670},
                {20, 20.5f},
                {33, 36},
                {110, 112.5f},
                {0.70f, 0.76f},
                {119, 122.5f}
            };

            descripcionMonedas = new String[numeroMonedas];
            valorMonedas = new float[numeroMonedas][2];

            for (int i = 0; i < numeroMonedas; i++) {
                try {
                    descripcionMonedas[i] = defaultDescripcionMonedas[i];
                } catch (java.lang.ArrayIndexOutOfBoundsException ex) {
                    descripcionMonedas[i] = "";
                }
            }

            for (int i = 0; i < numeroMonedas; i++) {
                try {
                    valorMonedas[i][0] = defaultValorMonedas[i][0];
                    valorMonedas[i][1] = defaultValorMonedas[i][1];
                } catch (java.lang.ArrayIndexOutOfBoundsException ex) {
                    valorMonedas[i][0] = 0;
                    valorMonedas[i][1] = 0;
                }
            }
                
            } else {
                java.util.logging.Logger.getLogger(Equivalencias.class.getName()).log(java.util.logging.Level.SEVERE, "Initial array length must be between 5 and 25");
            }
        }


    public constructorClass() {

        descripcionMonedas = new String[]{
            "dolar estadounidense",
            "euros",
            "colones",
            "pesos mexicanos",
            "cordobas oro",
            "pesos argentinos",
            "libra esterlina",
            "yen"
            };

        valorMonedas = new float[][]{
            {1, 1},
            {0.85f, 0.91f},
            {660, 670},
            {20, 20.5f},
            {33, 36},
            {110, 112.5f},
            {0.70f, 0.76f},
            {119, 122.5f}
        };
    }

    // Funciones setter y getter para trabajar con variables privadas fuera de la clase
    public void setValorMonedas(float[][] valorMonedas) {
        this.valorMonedas = valorMonedas;
    }

    public void setDescripcionMonedas(String[] descripcionMonedas) {
        this.descripcionMonedas = descripcionMonedas;
    }

    public float[][] getValorMonedas() {
        return this.valorMonedas;
    }

    public String[] getDescripcionMonedas() {
        return this.descripcionMonedas;
    }

    // Definicion de variables privadas
    private String[] descripcionMonedas;
    private float[][] valorMonedas;
    private String[] defaultDescripcionMonedas;
    private float[][] defaultValorMonedas;

}


// Clase equivalencias, computa los precios de compra y venta de la moneda seleccionada
public class Equivalencias{

    private static int posicionMoneda(String monedaOrigen) {
        constructorClass equivalencias = new constructorClass();
        String[] descripcionMonedas = equivalencias.getDescripcionMonedas();
        int index = Arrays.asList(descripcionMonedas).indexOf(monedaOrigen.toLowerCase());

        return index;

    }

    public static float precioCompra(String monedaOrigen) {

        constructorClass equivalencias = new constructorClass();
        float[][] valorMonedas = equivalencias.getValorMonedas();
        float precioCompra;
        int indiceMoneda = posicionMoneda(monedaOrigen);

        precioCompra = valorMonedas[indiceMoneda][0];

        return precioCompra;
    }

    public static float precioVenta(String monedaOrigen) {

        constructorClass equivalencias = new constructorClass();
        float[][] valorMonedas = equivalencias.getValorMonedas();
        float precioVenta;
        int indiceMoneda = posicionMoneda(monedaOrigen);

        precioVenta = valorMonedas[indiceMoneda][1];

        return precioVenta;
    }

}
