function processNumber(number, callback) {
  setTimeout(() => {
    const result = number * 2;
    console.log(`Process number: ${result}`);
    callback(result);
  }, 1000);
}

function processNumbers(numbers) {
  processNumber(numbers[0], (result1) => {
    processNumber(numbers[1], (result2) => {
      processNumber(numbers[2], (result3) => {
        console.log('All number processed');
      });
    });
  });
}

// Test the function
const numbers = [1, 3, 5];
processNumbers(numbers);
