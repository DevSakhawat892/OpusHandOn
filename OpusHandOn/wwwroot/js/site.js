

$(function () {
   getProducts()
   $("#btnSave").show();
   $("#btnUpdate").hide();
});
var baseUrl = "http://localhost:5217/";

// GetAll Product
function getProducts() {
   $.ajax({
      url: baseUrl + "Products/GetAll",
      type: "GET",
      dataType: "json",
      contentType: "application/json",
      success: function (res) {
         var h = "";
         $.each(res.data, function (k, v) {
            h += "<tr>"
            h += "<td>" + v.productCode + "</td>"
            h += "<td>" + v.productName + "</td>"
            h += "<td>" + v.unitPrice + "</td>"
            h += "<td><button id='btnEdit' class='btn btn-info me-2'data-bs-toggle='modal' data-bs-target='#productModal' onclick='Edit(" + v.id + ")'>Edit</button>"
            h += "<button id='btnRemove' class='btn btn-danger' onclick='Delete(" + v.id + ")'>Delete</button></td>"
            h += "</tr>"
            $("#ProdTable").html(h);
         })

      },
      error: function (err) {
         console.log(err);
      }
   });
}

// Save product
function Save() {
   var product = {
      productCode: $("#ProductCode").val(),
      productName: $("#ProductName").val(),
      unitPrice: $("#UnitPrice").val()
   };
   $.ajax({
      url: baseUrl + "Products/Create",
      method: "POST",
      type: "application/json",
      dataType: "JSON",
      data: product,
      success: function (res) {
         console.log(res);
         getProducts();
         modalHidden();
      },
      error: function (er) {
         console.log(er)
      }
   });
}

// Delete reacord from table.
function Delete(id) {
   if (confirm('Are you sure, You want to delete this record?')) {
      $.ajax({
         /*url: "/Products/Delete/" + id,*/
         url: "/Products/Delete?id=" + id,
         type: "post",
         contentType: "application/json",
         dataType: "JSON",
         success: function (res) {
            console.log(res.data)
            getProducts();
         },
         error: function (er) {
            console.log(er)
         }
      })
   }
}

// Update Record
function Edit(id) {
   $("#btnSave").hide();
   $("#btnUpdate").show();
   $.ajax({
      url: "/Products/Edit?id=" + id,
      type: "GET",
      contentType: "application/json",
      dataType: "json",
      success: function (res) {
         $("#Id").val(res.id);
         $("#ProductCode").val(res.productCode);
         $("#ProductName").val(res.productName);
         $("#UnitPrice").val(res.unitPrice);
      },
      error: function (err) {
         alert(err);
      }
   });
}

function Update() {
   var product = {
      id : $("#Id").val(),
      productCode: $("#ProductCode").val(),
      productName: $("#ProductName").val(),
      unitPrice: $("#UnitPrice").val()
   };
   $.ajax({
      url: baseUrl + "Products/Update",
      method: "POST",
      type: "application/json",
      dataType: "JSON",
      data: product,
      success: function (res) {
         console.log(res);
         getProducts();
         modalHidden();
      },
      error: function (er) {
         console.log(er)
      }
   });
}


// Hiden modal
function modalHidden() {
   modalClear();
   $("#productModal").modal('hide');
}

// Clear modal input fields
function modalClear() {
   $("#Id").val('');
   $("#ProductCode").val('');
   $("#ProductName").val('');
   $("#UnitPrice").val('');
   $("#btnSave").show();
   $("#btnUpdate").hide();
}