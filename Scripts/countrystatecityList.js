$(document).ready(function () {
    // Country selection change event
    $("#CountryId").change(function () {
        var countryId = $(this).val();

        if (!countryId) {
            // Clear and reset state and city dropdowns
            var stateSelect = $("#StateId");
            stateSelect.empty();
            stateSelect.append($('<option/>', { value: 0, text: "Select State" }));

            var citySelect = $("#CityId");
            citySelect.empty();
            citySelect.append($('<option/>', { value: 0, text: "Select City" }));
        } else {
            // Fetch states based on selected country
            $.ajax({
                type: "GET",
                url: "/Register/LoadStateByCountryId",
                data: { countryId: countryId },
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var stateSelect = $("#StateId");
                    stateSelect.empty();
                    stateSelect.append($('<option/>', { value: 0, text: "Select State" }));

                    $.each(data, function (index, item) {
                        stateSelect.append($('<option/>', { value: item.Value, text: item.Text }));
                    });
                },
                error: function () {
                    alert("Error while fetching states");
                }
            });
        }
    });

    // State selection change event
    $("#StateId").change(function () {
        var stateId = $(this).val();

        if (!stateId) {
            // Clear and reset city dropdown
            var citySelect = $("#CityId");
            citySelect.empty();
            citySelect.append($('<option/>', { value: 0, text: "Select City" }));
        } else {
            // Fetch cities based on selected state
            $.ajax({
                type: "GET",
                url: "/Register/LoadCityByStateId",
                data: { stateId: stateId },
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var citySelect = $("#CityId");
                    citySelect.empty();
                    citySelect.append($('<option/>', { value: 0, text: "Select City" }));

                    $.each(data, function (index, item) {
                        citySelect.append($('<option/>', { value: item.Value, text: item.Text }));
                    });
                },
                error: function () {
                    alert("Error while fetching cities");
                }
            });
        }
    });
});
