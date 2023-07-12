$(document).ready(function() {
  // Initialize the form and table
  loadTableData();
  populateCarriers();
  populateStates();
  populatePlans();

  function populateCarriers() {
    $.ajax({
        url: 'http://localhost:5049/api/carrier', // Replace with your API endpoint
        method: 'GET',
        success: function(response) {
        
        var select = $('#carrier');
  
        select.empty();
        
        response.forEach(function(plan) {
            select.append($('<option>', {
            value: plan.code,
            text: plan.code
            }));
        });
        },
        error: function() {
        console.log('Error occurred while fetching plans.');
        }
    });
  }

  function populateStates() {
    $.ajax({
      url: 'http://localhost:5049/api/state', // Replace with your API endpoint
      method: 'GET',
      success: function(response) {
        var select = $('#state');
        select.empty();
        select.append($('<option>', {
          value: '*',
          text: '-- Todos --'
        }));
        response.forEach(function(state) {
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
      
      var select = $('#listPlans');

      select.empty();
      
      response.forEach(function(plan) {
          select.append($('<option>', {
          value: plan.id,
          text: plan.code
          }));
      });
      },
      error: function() {
      console.log('Error occurred while fetching plans.');
      }
  });
  }


  $('#ageRangeMin').on('blur', function() {
    var ageMin = parseInt($(this).val());
    var ageMax = parseInt($('#ageRangeMax').val());
    if (isNaN(ageMin) || ageMin < 18 || ageMin > 150) {
      // Autofill with the minimum value if invalid
      $(this).val(18);
    }

    if (!isNaN(ageMax) && ageMax < ageMin) {
      // Set maximum value equal to the minimum value
      $('#ageRangeMax').val(ageMin);
    }
  });

  
  $('#ageRangeMax').on('blur', function() {
    var ageMin = parseInt($('#ageRangeMin').val());
    var ageMax = parseInt($(this).val());
    if (isNaN(ageMax) || ageMax < 18 || ageMax > 150) {
      // Autofill with the maximum value if invalid
      $(this).val(150);
    }
    if (!isNaN(ageMin) && ageMax < ageMin) {
      // Set maximum value equal to the minimum value
      $(this).val(ageMin);
    }
  });

  // Event handler for opening the form
  $('#openFormBtn').click(function() {
    clearForm();
    showForm();

    $('#monthOfBirth').val($('#monthOfBirth option:first').val());
    $('#carrier').val($('#carrier option:first').val());
    $('#state').val($('#state option:first').val());
    $('#ageRangeMin').focus();

  });

  // Event handler for canceling the form
  $('#cancelBtn').click(function() {
    hideForm();
  });

  // Event handler for saving the form data
  $('#maintenanceForm').submit(function(e) {
    e.preventDefault(); // Prevent form submission

    // Get form values
    var entryId       = $('#entryId').val();
    var carrier       = $('#carrier').val();
    var state         = $('#state').val();
    var monthOfBirth  = $('#monthOfBirth').val();
    var ageRangeMin   = $('#ageRangeMin').val();
    var ageRangeMax   = $('#ageRangeMax').val();
    var premium       = $('#premium').val();
    var listPlans     = $('#listPlans');

    

    // Validate premium is a valid decimal value
    if (isNaN(parseFloat(premium))) {
      alert('Please enter a valid decimal value for the premium.');
      return;
    }

    var listPlansObjects = [];
    listPlans.find('option:selected').each(function(){
      listPlansObjects.push({ PremiumDataId: parseInt(entryId) || 0, planId: parseInt($(this).val()), code: $(this).text() });
    });


    var data =  {
      "premiumData": {
        id          : parseInt(entryId) || 0,
        carrier     :carrier,
        state       :state,
        monthOfBirth:parseInt(monthOfBirth),
        ageRangeMin :parseInt(ageRangeMin),
        ageRangeMax :parseInt(ageRangeMax),
        premium     :parseFloat(premium),
        listPlans   :listPlansObjects
      }
    };

    if (confirm('Are you sure you want to save this entry?')) {
      if (entryId) {
        updateEntry(data);
      } else {
        createEntry(data);
      }

      // Clear the form and hide it
      clearForm();
      hideForm();
    }
  });

  // Event delegation for editing an entry
  $('#maintenanceTable').on('click', '.editBtn', function() {
    var entryId = $(this).data('entry-id');
    var entry = getEntryById(entryId);

    if (entry) {
      populateForm(entry);
      showForm();
    }
  });

  // Event delegation for editing an entry
  $('#maintenanceTable').on('click', '.editBtn', function() {
    var entryId = $(this).data('entry-id');
    editEntry(entryId);
  });

  // Event delegation for deleting an entry
  $('#maintenanceTable').on('click', '.deleteBtn', function() {
    
    var entryId = $(this).data('entry-id');
    showDeleteConfirmation(entryId);
  });

  // Event handler for confirming entry deletion
  $('#deleteConfirmBtn').click(function() {
    var entryId = $(this).data('entry-id');
    deleteEntry(entryId);
    hideDeleteConfirmation();
  });

  // Event handler for canceling entry deletion
  $('#deleteCancelBtn').click(function() {
    hideDeleteConfirmation();
  });

  // Function to load table data
  function loadTableData() {
    // AJAX code to fetch data and populate the table
    $.ajax({
      url: 'http://localhost:5049/api/premium',
      method: 'GET',
      dataType: 'json',
      success: function(response) {
        var tbody = $('#maintenanceTable tbody');
  
        // Clear existing table rows
        tbody.empty();
  
        // Iterate over the response data and populate the table
        for (var i = 0; i < response.length; i++) {
          var entry = response[i];
  
          // Create a new table row
          var row = $('<tr>');
  
          // Add data cells to the row
          row.append('<td>' + entry.id + '</td>');
          row.append('<td>' + entry.carrier + '</td>');
          row.append('<td>' + entry.state + '</td>');
          row.append('<td>' + (entry.monthOfBirth == 0 ? '*' : getMonthName(entry.monthOfBirth)) + '</td>');
          row.append('<td>' + entry.ageRangeMin + '</td>');
          row.append('<td>' + entry.ageRangeMax + '</td>');
          row.append('<td>' + entry.premium + '</td>');
  
          // Combine listPlans into a single string
          var listPlans = entry.listPlans.map(function(plan) {
            // return plan.planId;
            return plan.code;
          }).join(', ');
  
          row.append('<td>' + listPlans + '</td>');
  
          // Add action buttons
          row.append('<td><button class="editBtn" data-entry-id="' + entry.id + '">Edit</button> <button class="deleteBtn" data-entry-id="' + entry.id + '">Delete</button></td>');
  
          // Append the row to the table body
          tbody.append(row);
        }
      },
      error: function(xhr, status, error) {
        console.log('Error:', status, error, xhr);
      }
    });
  }

  function getMonthName(monthNumber) {
    var months = [
      'January',
      'February',
      'March',
      'April',
      'May',
      'June',
      'July',
      'August',
      'September',
      'October',
      'November',
      'December'
    ];
  
    return months[monthNumber - 1];
  }

  // Function to create a new entry
  function createEntry(data) {
    // AJAX code to create a new entry
    // After successful creation, refresh the table with the updated data
    console.log("new");
    console.log(data);

    $.ajax({
      url: 'http://localhost:5049/api/premium/CreatePremium',
      method: 'POST',
      dataType: 'json',
      contentType: 'application/json; chartset=utf-8',
      async: true,
      data: JSON.stringify(data),
      success: function(response) {
        // Log the successful creation message and the response data
        console.log('New entry created:');
        console.log(response);
  
        // Refresh the table with the updated data
        loadTableData();
      },
      error: function(xhr, status, error) {
        loadTableData();
        console.log('Error:', status, error, xhr);
      }
    });

  }

  // Function to update an existing entry
  function updateEntry(data) {
    // AJAX code to update the entry with the given entryId
    // After successful update, refresh the table with the updated data
    console.log("Edit");
    // console.log(JSON.stringify(data));


    $.ajax({
      // url: 'http://localhost:5049/api/premium/UpdatePremium',
      url: 'http://localhost:5049/api/premium',
      method: 'PUT',
      dataType: 'json',
      contentType: 'application/json; chartset=utf-8',
      data: JSON.stringify(data),
      success: function(response) {
        // Log the successful creation message and the response data
        console.log('Entry edited:');
        console.log(response);
  
        // Refresh the table with the updated data
        loadTableData();
      },
      error: function(xhr, status, error) {
        loadTableData();
        console.log('Error:', status, error, xhr);
      }
    });
  }

  // Function to delete an entry
  function deleteEntry(entryId) {
    // AJAX code to delete the entry with the given entryId
    // After successful deletion, refresh the table with the updated data
    console.log("Delete");

    $.ajax({
      // url: 'http://localhost:5049/api/premium/UpdatePremium',
      url: 'http://localhost:5049/api/premium/'+ entryId,
      method: 'DELETE',
      dataType: 'json',
      async: false,
      success: function(response) {
        // Log the successful creation message and the response data
        console.log('Entry edited:');
        console.log(response);
  
        // Refresh the table with the updated data
        loadTableData();
      },
      error: function(xhr, status, error) {
        console.log('Error:', status, error, xhr);
      }
    });
  }

  function editEntry(entryId) {
    // Retrieve the entry data using the entryId
    var entry = getEntryById(entryId);
  
    // Check if the entry exists
    if (entry) {
      // Pre-populate the form with the entry data
      populateForm(entry);
  
      // Show the form for editing
      showForm();
    }
  }

  // Function to retrieve an entry by its ID
  function getEntryById(entryId) {
    // AJAX code to fetch the entry with the given entryId
    // Return the entry object if found, otherwise return null
    var entry = null;

    $.ajax({
      url: 'http://localhost:5049/api/premium/' + entryId,
      method: 'GET',
      dataType: 'json',
      async: false,
      success: function(response) {
        entry = response;
      },
      error: function(xhr, status, error) {
        console.log('Error:', status, error, xhr);
      }
    });

    return entry;
  }

  // Function to populate the form with entry data
  function populateForm(entry) {
    // Populate the form fields with entry data
    $('#entryId').val(entry.id);
    $('#carrier').val(entry.carrier);
    $('#state').val(entry.state);
    $('#monthOfBirth').val(entry.monthOfBirth);
    $('#ageRangeMin').val(entry.ageRangeMin);
    $('#ageRangeMax').val(entry.ageRangeMax);
    $('#premium').val(entry.premium);
    $('#listPlans').val(entry.listPlans.map(plan => plan.planId));
  }

  // Function to clear the form fields
  function clearForm() {
    $('#entryId').val('');
    $('#carrier').val('');
    $('#state').val('');
    $('#monthOfBirth').val('');
    $('#ageRangeMin').val('');
    $('#ageRangeMax').val('');
    $('#premium').val('');
    $('#listPlans').val([]);
  }

  // Function to show the form
  function showForm() {
    $('#formContainer').show();
  }

  // Function to hide the form
  function hideForm() {
    $('#formContainer').hide();
  }

  // Function to show the delete confirmation modal
  function showDeleteConfirmation(entryId) {
    $('#deleteConfirmBtn').data('entry-id', entryId);
    $('#deleteConfirmationModal').show();
  }

  // Function to hide the delete confirmation modal
  function hideDeleteConfirmation() {
    $('#deleteConfirmBtn').data('entry-id', null);
    $('#deleteConfirmationModal').hide();
  }
});
