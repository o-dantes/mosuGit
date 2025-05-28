using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosu
{
    public class PIDController
    {
        public double Kp { get; set; }
        public double Ki { get; set; }
        public double Kd { get; set; }

        private double integral = 0;
        private double previousError = 0;

        public PIDController(double kp, double ki, double kd)
        {
            Kp = kp;
            Ki = ki;
            Kd = kd;
        }

        public double Update(double error, double dt)
        {
            integral += error * dt;

            // Антинасичення інтегральної складової
            const double integralMax = 100;
            if (integral > integralMax) integral = integralMax;
            else if (integral < -integralMax) integral = -integralMax;

            double derivative = (error - previousError) / dt;
            previousError = error;

            return Kp * error + Ki * integral + Kd * derivative;
        }

        public void Reset()
        {
            integral = 0;
            previousError = 0;
        }
    }
}
