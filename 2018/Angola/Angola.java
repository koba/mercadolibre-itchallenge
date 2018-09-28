import java.io.*;

public class Angola {
    
    static final long MODULO = 1000000007;
    
    static long[] cache;
 
    public static long pow(long x, long n, long p) {
        long result = 1;
        while (n > 0) {
            if ((n & 1) == 1) {
                result = (result * x) % p;
            }
 
            x = (x * x) % p;
            n = n >> 1;
        }
 
        return result;
    }
 
    private static long solveSingleRow(int width) {
        if (width == 0) {
            return 1;
        } else if (width < 0) {
            return 0;
        } else {
            if (cache[width] == -1) {
                cache[width] = (solveSingleRow(width - 1) + solveSingleRow(width - 2) + solveSingleRow(width - 3) + solveSingleRow(width - 4)) % MODULO;
            }
            return cache[width];
        }
    }
 
    private static long[][] solve(int height, int width) {
        long[][] a = new long[height + 1][width + 1];
        long[][] s = new long[height + 1][width + 1];

        cache = new long[width + 1];
 
        for (int w = 0; w <= width; w++) {
            cache[w] = -1;
        }
 
        for (int w = 1; w <= Math.min(width, 4); w++) {
            s[1][w] = 1;
        }
 
        for (int h = 1; h <= height; h++) {
            for (int w = 1; w <= width; w++) {
                long oneRow = solveSingleRow(w);
                a[h][w] = pow(oneRow, h, MODULO);
            }
 
            for (int w = 1; w <= width; w++) {
                long bad = 0;
                for (int l = 1; l <= w - 1; l++) {
                    bad += ((s[h][l] * a[h][w - l]) % MODULO);
                    bad = bad % MODULO;
                }
 
                s[h][w] = (a[h][w] - bad) % MODULO;
            }
 
        }
        
        return s;
    }
 
    public static void main(String[] args) throws Exception {
        BufferedReader br = new BufferedReader(new FileReader(new File("").getAbsolutePath() + "/../_docs/Angola/input Lego.txt"));
        long[][] s = solve(1000, 1000);

        try {
            int i = 0;
            String line = br.readLine();
            while (line != null) {
                if (i++ == 0) {
                    line = br.readLine();
                    continue;
                }

                String[] aux = line.split(" ");

                int n = Integer.parseInt(aux[0]);
                int m = Integer.parseInt(aux[1]);
                
                long result = s[n][m];

                while (result < 0) {
                    result = result + MODULO;
                }

                System.out.print(result);

                line = br.readLine();
            }
        } 
        finally {
            br.close();
        }
        
        System.out.println();
    }
}