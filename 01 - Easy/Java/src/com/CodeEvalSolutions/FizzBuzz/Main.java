package com.CodeEvalSolutions.FizzBuzz;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class Main
{
    public static void main(String[] args) {
        List<String> allLines = null;

        try {
            allLines = readFile(new File(args[0]));
        } catch (IOException e) {
            e.printStackTrace();
        }

        for(String singleLine : allLines)
        {
            String[] data = singleLine.split(" ");
            StringBuilder finalAnswer = new StringBuilder();

            for(int i=1; i<=Integer.parseInt(data[2]); i++)
            {
                boolean isFizz = i % Integer.parseInt(data[0]) == 0;
                boolean isBuzz = i % Integer.parseInt(data[1]) == 0;

                if (isFizz) finalAnswer.append("F");
                if (isBuzz) finalAnswer.append("B");
                if (isFizz || isBuzz) finalAnswer.append(" ");

                if (!isFizz && !isBuzz) finalAnswer.append(i + " ");
            }

            System.out.println(finalAnswer.substring(0, finalAnswer.length() - 1));
        }


    }

    private static List<String> readFile(File fin) throws IOException {

        ArrayList<String> file = new ArrayList<String>();

        FileInputStream fis = new FileInputStream(fin);

        BufferedReader br = new BufferedReader(new InputStreamReader(fis));

        String line = null;

        while ((line = br.readLine()) != null) {
            file.add(line);
        }

        br.close();

        return file;
    }
}
