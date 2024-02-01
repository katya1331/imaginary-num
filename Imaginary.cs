using System;
using System.Linq;
using static System.Convert;

namespace числа_которые_корень_отрицательный_хехе_
{
    public class Imaginary
    {
        public Imaginary()
        {
            Real = 0;
            Imag = 0;
        }

        public Imaginary(int r, int i)
        {
            Real = r;
            Imag = i;
        }
        
        private int Imag { get; set; }
        private int Real { get; set; }

        public string Value
        {
            get
            {
                return this.ToString();
            }
            set
            {
                string[] parts = value.Split(new char[] { '-', '+', 'I', 'i' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && (value.Contains('i') || value.Contains('I')))
                {
                    try
                    {
                        Real = ToInt32(value.Substring(0, parts[0].Length + 1));
                    }
                    catch
                    {
                        Real = ToInt32(value.Substring(0, parts[0].Length));
                    }
                    Imag = ToInt32(value.Substring(value.Length - 2 - parts[1].Length, parts[1].Length + 1));
                }
                else
                {
                    throw new Exception("Неверный формат");
                }
            }
        }

        public int GetImaginaryPart
        {
            get { return Imag; }
        }

        public int GetRealPart
        {
            get { return Real; }
        }

        public static Imaginary operator +(Imaginary num1, Imaginary num2)
        {
            return new Imaginary(num1.Real + num2.Real, num1.Imag + num2.Imag);
        }

        public static Imaginary operator -(Imaginary num1, Imaginary num2)
        {
            return new Imaginary(num1.Real - num2.Real, num1.Imag - num2.Imag);
        }

        public static Imaginary operator *(Imaginary num1, Imaginary num2)
        {
            //(a + bi) * (c + di) = (ac - bd) + (ad + bc)i
            int resultReal = num1.Real * num2.Real - num1.Imag * num2.Imag;
            int resultImag = num1.Real * num2.Imag + num1.Imag * num2.Real;

            return new Imaginary(resultReal, resultImag);
        }

        public static Imaginary operator /(Imaginary num1, Imaginary num2)
        {
            //(a + bi) / (c + di) = (ac + bd) / (c^2 + d^2) + (bc - ad) / (c^2 + d^2)i
            int denominator = num2.Real * num2.Real + num2.Imag * num2.Imag;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно.");
            }

            int resultReal = (num1.Real * num2.Real + num1.Imag * num2.Imag) / denominator;
            int resultImag = (num1.Imag * num2.Real - num1.Real * num2.Imag) / denominator;

            return new Imaginary(resultReal, resultImag);
        }

        public double Magnitude()
        {
            // Magnitude: |a + bi| = sqrt(a^2 + b^2)
            return Math.Sqrt(Real * Real + Imag * Imag);
        }

        public double Phase()
        {
            // Phase: arg(a + bi) = atan2(b, a)
            return Math.Atan2(Imag, Real);
        }

        public static Imaginary FromPolarCoordinates(double magnitude, double phase)
        {
            // Convert from polar coordinates to rectangular coordinates: a + bi = r * cos(theta) + r * sin(theta)i
            int realPart = (int)(magnitude * Math.Cos(phase));
            int imagPart = (int)(magnitude * Math.Sin(phase));

            return new Imaginary(realPart, imagPart);
        }

        public void Square()
        {
            // (a + bi)^2 = a^2 + 2abi - b^2
            int newReal = Real * Real - Imag * Imag;
            int newImag = 2 * Real * Imag;

            Real = newReal;
            Imag = newImag;
        }

        public override string ToString()
        {
            if (Imag < 0)
            {
                return $"{Real} - {-Imag}i";
            }
            else
            {
                return $"{Real} + {Imag}i";
            }
        }

        public string ToAlgebraicForm()
        {
            return ToString();
        }

        public string ToPolarForm()
        {
            // Polar form: r * (cos(theta) + sin(theta)i)
            double magnitude = Magnitude();
            double phase = Phase();

            return $"{magnitude} * (cos({phase}) + sin({phase})i)";
        }

        public string ToExponentialForm()
        {
            // Exponential form: r * e^(i * theta)
            double magnitude = Magnitude();
            double phase = Phase();

            return $"{magnitude} * e^(i * {phase})";
        }
    }
}
