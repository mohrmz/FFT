using System;
using System.Diagnostics;

public class Program
{

    
   
    class complex
    {
        public double real = 0.0;
        public double imag = 0.0;
   
        public complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }
        public string ToString()
        {
            string data =$"{real.ToString()}  {imag.ToString()}i";
            return data;
        }

        public static complex from_polar(double r, double radians)
        {
            complex data = new complex(r * Math.Cos(radians), r * Math.Sin(radians));
            return data;
        }

        public static complex operator +(complex a, complex b)
        {
            complex data = new complex(a.real + b.real, a.imag + b.imag);
            return data;
        }

        public static complex operator -(complex a, complex b)
        {
            complex data = new complex(a.real - b.real, a.imag - b.imag);
            return data;
        }

        public static complex operator *(complex a, complex b)
        {
            complex data = new complex((a.real * b.real) - (a.imag * b.imag),
           (a.real * b.imag + (a.imag * b.real)));
            return data;
        }

       
    public static complex[] FFT(complex[] A)
    {
        int N = A.Length;
        complex[] B = new complex[N];
        complex[] r, BR, l, BL;
        if (N == 1)
        {
                B[0] = A[0];
            return B;
        }

        l = new complex[N / 2];
        r = new complex[N / 2];
        for (int k = 0; k < N / 2; k++)
        {
            l[k] = A[2 * k];
                r[k] = A[2 * k + 1];
        }

            BL = FFT(l);
            BR = FFT(r);


        complex omega = complex.from_polar(1, -2 * Math.PI  / N);
        complex z = new complex(1,0);
        for(int j=0;j<N;++j)
        {
                B[j] = BL[j % (N/2)] + z* BR[j % (N/2)];
            z = z * omega;
        }

        return B;
    }
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Enter The number of complex numbers");
            int num = int.Parse(Console.ReadLine());
            complex[] input = new complex[num];
            for (int i = 0; i < num; ++i)
            {
                Console.WriteLine($"Enter {i} complex number");
                Console.WriteLine($"Real");
                int real = int.Parse(Console.ReadLine());
                Console.WriteLine($"imaginary");
                int imaginary = int.Parse(Console.ReadLine());
                complex complex = new complex(real, imaginary);
                input.SetValue(complex, i);
            }
            //complex[] input = { new complex(1.0, -2.0), new complex(3.0, 4.0), new complex(5.0, -6.0), new complex(7.0, 8.0) };


            var output =  FFT(input);

            Console.Clear();
            Console.WriteLine("inputs:");
            foreach (complex c in input)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine("Results:");
            foreach (complex c in output)
            {
                Console.WriteLine(c.ToString());
            }
           
            Console.ReadLine();
        }
    }
}
