using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaycastingEngine {
    class Vec2 {
        public Vec2(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public Vec2(Vec2 v) {
            x = v.x;
            y = v.y;
        }

        public void Scale(double scalar) {
            x *= scalar;
            y *= scalar;
        }

        public void Translate(Vec2 t) {
            x += t.x;
            y += t.y;
        }

        // the angle is in radians!
        public void Rotate(double angle) {
            x = Math.Cos(angle) * x - Math.Sin(angle) * y;
            y = Math.Sin(angle) * x + Math.Cos(angle) * y;
        }

        public void Normalize() {
            double norm = Norm(this);
            x /= norm;
            y /= norm;
        }

        public static double Norm(Vec2 v) {
            return Math.Sqrt(Dot(v, v));
        }

        public static double Dot(Vec2 a, Vec2 b) {
            return a.x * b.x + a.y * b.y;
        }

        public static double Angle(Vec2 a, Vec2 b) {
            double cos = Dot(a, b) / (Norm(a) * Norm(b));
            return Math.Acos(cos);
        }

        public static Vec2 operator+(Vec2 a, Vec2 b) {
            return new Vec2(a.x + b.x, a.y + b.y);
        }

        public static Vec2 operator*(Vec2 a, double b) {
            return new Vec2(a.x * b, a.y * b);
        }

        public double x { get; private set; }
        public double y { get; private set; }
    }
}
