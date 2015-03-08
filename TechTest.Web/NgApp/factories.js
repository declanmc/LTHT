'use strict';

app.factory('person', [function () {

    var person = function (personId, firstName, lastName, isAuthorised, isValid, isEnabled, colours) {
        this.personId = personId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.isAuthorised = isAuthorised;
        this.isValid = isValid;
        this.isEnabled = isEnabled;
        this.colours = colours;
    };

    person.create = function (data) {
        return new person(
            data.PersonId,
            data.FirstName,
            data.LastName,
            data.IsAuthorised,
            data.IsValid,
            data.IsEnabled,
            data.Colours
            );
    };

    person.prototype.getFullName = function () {
        return this.firstName + ' ' + this.lastName;
    };

    function nameIsPalindrome(firstName, lastName) {
        var fullName = firstName + lastName;
        var nameToTest = fullName.replace(" ", "").toLowerCase();
        return nameToTest === nameToTest.split('').reverse().join('');
    }

    person.prototype.isPalindrome = function () {
        return nameIsPalindrome(this.firstName, this.lastName);
    };

    person.prototype.isPalindromeText = function () {
        return nameIsPalindrome(this.firstName, this.lastName) ? "Yes" : "No";
    };

    person.prototype.authorised = function () {
        return this.isAuthorised ? "Yes" : "No";
    };

    person.prototype.enabled = function () {
        return this.isEnabled ? "Yes" : "No";
    };

    person.prototype.getColours = function () {
        var colours = "";
        angular.forEach(this.colours, function (colour) {
            colours = colours + colour.Name + ", ";
        });

        return colours.substring(0, colours.length - 2);
    };

    function getColourIndex(colours, colour) {
        return colours.map(function (e) { return e.Name; }).indexOf(colour.Name);
    }

    person.prototype.hasColour = function (colour) {
        return getColourIndex(this.colours, colour) !== -1;
    };

    person.prototype.addColour = function (colour) {
        var colourIndex = getColourIndex(this.colours, colour);
        if (colourIndex === -1) {
            this.colours.push(colour);
        } else {
            this.colours.splice(colourIndex, 1);
        }
    };

    return person;
}]);