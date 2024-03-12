// Practice 2.2
// elements
using LearningStatistics.src;
using LearningStatistics.src.distributions;
using LearningStatistics.src.distributions.continuous;
using LearningStatistics.src.distributions.discrete;
using LearningStatistics.src.extensions;

int[] elementsA = { 0, 3, 3, 5, 5, 5, 5, 7, 7, 10 };
int[] elementsB = { 0, 1, 2, 3, 5, 5, 7, 8, 9, 10 };
int[] elementsC = { 3, 4, 4, 5, 5, 5, 5, 6, 6, 7 };

// Create Instances
var objA = new Sequence(elementsA);
var objB = new Sequence(elementsB);
var objC = new Sequence(elementsC);

// Display calculated Mean Differnces.
Console.WriteLine("Mean Differnce of Element A is {0}", objA.MeanDiffernce());
Console.WriteLine("Mean Differnce of element B is {0}", objB.MeanDiffernce());
Console.WriteLine("Mean Differnce of Element C is {0}", objC.MeanDiffernce());

// Display Calculated Gini Indexes.
Console.WriteLine("Gini Index of Element A is {0}", objA.GiniIndex());
Console.WriteLine("Gini Index of Element B is {0}", objB.GiniIndex());
Console.WriteLine("Gini Index of Element C is {0}", objC.GiniIndex());

// Section2 Practice 2.3

// Create Instances
int[] histogramA = { 32, 19, 10, 24, 15 };
int[] histogramB = { 28, 13, 18, 29, 12 };

// Create Instances
var histA = new Histogram(histogramA);
var histB = new Histogram(histogramB);

// Display Calculated Entropies.
Console.WriteLine("Entropy of Histogram A is {0}", histA.Entropy());
Console.WriteLine("Entropy of Histogram B is {0}", histB.Entropy());




var saikoro = new Saikoro();
Console.WriteLine("Integral; {0}", saikoro.Sum());
Console.WriteLine("E[X]; {0}", saikoro.Expectation());
Console.WriteLine("V[X]; {0}", saikoro.Variant());

var uni = new UniformDistribution();
Console.WriteLine("Integral; {0}", uni.Integral());
Console.WriteLine("E[X]; {0}", uni.Expectation());
Console.WriteLine("V[X]; {0}", uni.Variant());

Console.WriteLine("5!; {0}", 5.Factorial());
Console.WriteLine("5P3; {0}", 5.Permutation(3));
Console.WriteLine("5C3; {0}", 5.Combination(3));

