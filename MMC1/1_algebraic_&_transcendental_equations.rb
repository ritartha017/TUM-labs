# frozen_string_literal: true

require 'benchmark'
require 'rubocop'

def f(x)
 # x**3 - 26 * x + 43 # f1
  Math.cos(x) + 2*x - 0.5    #f2
end

def fi(x)
 # (x**3 + 43) / -26.to_f # f1
  -(Math.cos(x) - 0.5)/2     #f2
end

def df(x)
 # 3 * x**2 - 26 # f1
   2 - Math.sin(x)           #f2
end

def bisect(a, b, eps)
  c = a
  c = b if f(a).negative?
  d = a + b - c
  k = error = 0
  until (c - d).abs <= eps
    x = c + (d - c) / 2.to_f
    k += 1
    fx = f(x)
    break if fx.zero?

    fx.positive? ? c = x : d = x
    error = (c - d).abs
  end
  { x: x, k: k, error: error }
end

def siter(a, eps, nmax)
  x = k = error = 0
  y = a
  until (y - x).abs <= eps || k >= nmax
    k += 1
    x = y
    y = fi(x)
    error = y - x
  end
  error = (y - x).abs
  tf = k < nmax
  x1 = x
  { x: x1, k: k, error: error, tf: tf }
end

def newton(a, eps, nmax)
  x1 = a
  x0 = k = error = 0
  until (x1 - x0).abs <= eps || k >= nmax
    k += 1
    x0 = x1
    x1 = x0 - (f(x0).to_f / df(x0))
    error = (x1 - x0).abs
  end
  { x: x0, k: k, error: error }
end

# puts 'For f(x)=x^3 - 26x + 43 && roots: 1.[-6, -5] 2.[1, 2] 3.[3, 4]'
# puts "\nBisect\n"
# p r1b = bisect(-6, -5, 10**-6)
# p r2b = bisect(1, 2, 10**-6)
# p r3b = bisect(3, 4, 10**-6)

# puts "\nNewton\n"
# p r1n = newton(-6, 10**-6, 100)
# p r1n = newton(1, 10**-6, 100)
# p r1n = newton(3, 10**-6, 100)

# puts "\nSiter\n"
# p r1s = siter(-6, 10**-6, 100)
# p r2s = siter(1, 10**-6, 100)
# p r3s = siter(3, 10**-6, 100)

# puts ''
# Benchmark.bm do |x|
#  x.report('Bisect') { 100_000.times { bisect(-6, -5, 10**-4) } }
#  x.report('Newton') { 100_000.times { newton(-6, 10**-4, 50) } }
#  x.report('Siter ') { 100_000.times { siter(-6, 10**-4, 50) } }
# end

# #################################f2##################################

puts "For f(x)=cos(x) + 2x - 0.5 && roots: 1.[-1, 0]"
puts "\n[Bisect] #{ r1b = bisect(-1, 0, 10**-6) }"  +
     "\n[Newton] #{ r1n = newton(-1, 10**-6, 50) }" +
     "\n[Siter ] #{ r1s = siter(-1, 10**-6, 50) }\n\n"

Benchmark.bm do |x|
  x.report("Bisect") { 100_000.times { bisect(-1, 0, 10**-4) } }
  x.report("Newton") { 100_000.times { newton(-1, 10**-4, 50) } }
  x.report("Siter ") { 100_000.times { siter(-1, 10**-4, 50) } }
end
