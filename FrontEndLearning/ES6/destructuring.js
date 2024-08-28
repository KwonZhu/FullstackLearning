const person = {
  name: 'John',
  age: 18,
  location: {
    city: 'Melbourne',
    country: 'Australia',
  },
};

const {
  name: myName,
  age: myAge,
  location: { city },
} = person;
console.log('destructed name', myName);
try {
  console.log('location', location); //location is not defined
} catch (e) {
  console.log('Error', e.message);
}
console.log('destructed city', city);

// The error occurs because location is not directly destructured or assigned as a standalone variable.
// Instead, the code destructures the properties city from the location object but does not keep a reference to the location object itself.

// destructure city and country while also keeping a reference to the location object
const {
  name,
  age,
  location,
  location: { city, country },
} = person;
console.log(location); // { city: 'Melbourne', country: 'Australia' }
console.log(city); // 'Melbourne'
