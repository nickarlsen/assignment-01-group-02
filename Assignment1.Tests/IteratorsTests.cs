using Xunit;
namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void stream_of_streams_of_Ts_return_stream_of_Ts() {
        //Arrange
        IEnumerable<IEnumerable<int>> input = new[] {new [] {3,4}, new [] {1,2}};
        //Act
        var output = Iterators.Flatten(input);

        //Assert
        Assert.Equal(new [] {3,4,1,2}, output);
    }
    

    [Fact] 
    public void filter_test() {
        //Arrange
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        IEnumerable<int> input = new[] {1,2,3,4};
        //Act
        var output = Iterators.Filter(input, even);
        
        //Assert 
        Assert.Equal(new [] {2, 4}, output);

    }

    
}