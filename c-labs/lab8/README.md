### *A simple C program for Space, Swaps and Time Complexity plot of Bubble Sort and Counting Sort*    

## To plot the graphs:

1. Open *Gnuplot* simply using
gnuplot
   
2. Use this command to plot the needed complexity graph:   
```plot './counting_sort.txt' using 1:2 with linespoints t "Time Random Case", './counting_sort.txt' using 1:3 with linespoints t "Time Best Case", './counting_sort.txt' using 1:4 with linespoints t "Time Worts Case", './counting_sort.txt' using 1:5 with linespoints t "Swaps Worst (Worst C)", './counting_sort.txt' using 1:6 with linespoints t "Comparisons (Worst C)", './counting_sort.txt' using 1:7 with linespoints t "Memory (Worst C)"; set output 'output.png';```