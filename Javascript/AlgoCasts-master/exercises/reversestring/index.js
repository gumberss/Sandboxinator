// --- Directions
// Given a string, return a new string with the reversed
// order of characters
// --- Examples
//   reverse('apple') === 'elppa'
//   reverse('hello') === 'olleh'
//   reverse('Greetings!') === '!sgniteerG'

function reverse(str) {
  return str.split('').reduce((acc, c) =>  c + acc)
}



/**
 * var newString = "";

    for(var i = 0; i< str.length;i++){
        newString = str[i] + newString
    }
    
    return newString
 */

/*
function reverse(str) {
    return reverseStr(str, "", str.length-1)
}

function reverseStr(str, newString, count) {

    if (count == -1) return newString

    return reverseStr(str,  newString + str[count], --count)
}
*/

module.exports = reverse;
