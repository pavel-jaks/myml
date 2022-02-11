using myml.NN;
using MNIST.IO;


var nn = new Sequential(28 * 28, new int[] {16, 16, 10});

