/*
Flight Stops
given by an array of flights, returns stops statement to user.
ex.
flights: [{ origin: 'MEL', destination: 'CAN' }] -> 'Direct'
flights: [{ origin: 'MEL', destination: 'CAN' }, { origin: 'CAN', destination: 'PVG' }] -> '1 stop'
flights: [{ origin: 'MEL', destination: 'HKG' }, { HKG - CAN }, { origin: 'CAN', destination: 'PVG' }] -> '2 stops'
flights: [{ origin: 'MEL', destination: 'HKG' }, { HKG - CAN }, { CAN - SNG }, ..., { origin: 'CAN', destination: 'PVG' }] -> 'n stops'

arr.length 1 -> Direct 
2 -> 1 stop 
3 -> 2 stops 
4 -> 3 stops 
11 -> The DreamLine
27 -> Around the world
n -> ... stops
*/

//for testing usage
const flights = [
  { origin: 'MEL', destination: 'HKG' },
  { origin: 'HKG', destination: 'CAN' },
  { origin: 'CAN', destination: 'PVG' },
];

// version 1
console.log(getStops(flights));
function getStops(flights) {
  const stop = flights.length - 1;
  switch (stop) {
    case 0:
      return 'Direct';
    case 1:
      return '1 stop';
    case 11:
      return 'The dreamLine';
    case 27:
      return 'Around the world';
    default:
      return stop + ' stops:';
  }
}
