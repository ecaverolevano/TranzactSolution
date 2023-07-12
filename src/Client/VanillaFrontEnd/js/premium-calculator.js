$(document).ready(function() {

    $('#dateOfBirth').on('input', function() {

        calculateAge();
    
    });

    function calculateAge() {
    var dateOfBirth = $('#dateOfBirth').val();
    var dob = new Date(dateOfBirth);
    var today = new Date();

    var age = today.getFullYear() - dob.getFullYear();

    // Check if the birthday hasn't occurred yet this year
    if (
        today.getMonth() < dob.getMonth() ||
        (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate())
    ) {
        age--;
    }

    // Set the calculated age in the #age input field
    $('#age').val(age);
    }

    function populateStates() {
        $.ajax({
          url: 'http://localhost:5049/api/state', // Replace with your API endpoint
          method: 'GET',
          success: function(response) {
            var select = $('#state');
            select.empty();
            select.append($('<option>', {
              value: '',
              text: '-- Select State --'
            }));
            response.forEach(function(state, index) {
              select.append($('<option>', {
                value: state.code,
                text: state.code + ' - ' + state.description
              }));
            });
          },
          error: function() {
            console.log('Error occurred while fetching states.');
          }
        });
      }

    function populatePlans() {
    $.ajax({
        url: 'http://localhost:5049/api/plan', // Replace with your API endpoint
        method: 'GET',
        success: function(response) {
        
        var select = $('#plan');

        select.empty();
        select.append($('<option>', {
            value: '',
            text: '-- Select Plan --'
        }));
        response.forEach(function(plan) {
            select.append($('<option>', {
            value: plan.id,
            text: plan.code
            }));
        });
        },
        error: function() {
        console.log('Error occurred while fetching states.');
        }
    });
    }

    function filterData() {
     
      var DateOfBirth   = $('#dateOfBirth').val();
      var State         = $('#state').val();
      var PlanId        = $('#plan').val();
      var Age           = $('#age').val();
      var Period        = $('#listPeriod').val();

      if (DateOfBirth && State && PlanId && Age) {
        var data = { 
            DateOfBirth: DateOfBirth, 
            State: State, 
            Age: Age,
            PlanId: PlanId 
        };

        
        $.ajax({
            url: 'http://localhost:5049/api/premium',
            method: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function(response) {
              // Handle the success response


                // Clear previous results
                $('#resultTable tbody').empty();

                if (response && response.length > 0) {
                    // Add filtered rows to the table
                    response.forEach(function (item) {
                        var valuePeriod = parseInt(Period); // Convert period value to integer
                        var monthlyPremium = item.premium / valuePeriod;
                        var anualPremium = item.premium * (12 /valuePeriod);

                      var planIds = item.listPlans.map(function(plan) { return plan.planId; }).join(', ');

                      $('#resultTable tbody').append(
                          '<tr>' +
                          '<td>' + item.carrier + '</td>' +
                          '<td>' + item.premium.toLocaleString('en-US', { style: 'currency', currency: 'USD' }) + '</td>' +
                          '<td>' + anualPremium.toLocaleString('en-US', { style: 'currency', currency: 'USD' }) + '</td>' +
                          '<td>' + monthlyPremium.toLocaleString('en-US', { style: 'currency', currency: 'USD' }) + '</td>' +
                          '</tr>'
                      );
                    });
                }else {
                  // Clear previous results
                  $('#resultTable tbody').empty();
            
                  // Show an alert or display a message indicating no data found
                  $('#resultTable tbody').append(
                    '<tr>' +
                    '<td colspan="4">No data found.</td>' +
                    '</tr>'
                  );
                }
            },
            error: function(xhr, status, error) {
              // Handle any errors that occur during the request
              console.log('Error:', status, error, xhr);
            }
        });
  
     
      }
      else{
          alert("You must complete all filters")
      }
    }

    $('#btnGetPremium').click(function() {
        
        filterData();
      });

      $('#listPeriod').change(function() {

          filterData()
        
      });
  
    // Initial data fetch
    populateStates();
    populatePlans();
  });
  