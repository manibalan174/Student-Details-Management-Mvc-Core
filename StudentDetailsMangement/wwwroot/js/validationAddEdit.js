
    function SubmitDetails() {
        if ($("#StudentDetilasForm").valid()) {
            $("#StudentDetilasForm").submit();
        }
        function getAge() {

            var dateString = $("#DateOfBirth").val();
            //alert(dateString)
            var today = new Date();
            var birthDate = new Date(dateString);
            var age = today.getFullYear() - birthDate.getFullYear();
            var m = today.getMonth() - birthDate.getMonth();
            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }
            $('#StudentAge').val(age);
            //if ($('#StudentAge').val() != "") {
            //    $('#StudentAge').prop("disabled", true);
            //}
            //else {
            //    $('#StudentAge').prop("disabled", false);;
            //}
        }
        function clear() {
            $("#FisrtName").val("");
            $("#LastName").val("");
            $("#DateOfBirth").val("");
            $("#Age").val("");
            $("#FavoriteSubject").val("");
            $("#InterestedCourse").val("");
            $("#MathsMark").val("");
            $("#ChemistryMark").val("");
            $("#ComputerScienceMark").val("");
        }
        $(function () {
        $("#StudentDetilasForm").validate({
            rules: {
                LastName:
                {
                    required: true,
                    maxlength: 50
                },
                Age:
                {
                    required: true,
                    maxlength: 3
                },
                FavoriteSubject:
                {
                    required: true,
                },
                MathsMark:
                {
                    required: true,
                    maxlength: 3
                },
                ChemistryMark:
                {
                    required: true,
                    maxlength: 3
                },
                ComputerScienceMark:
                {
                    required: true,
                    maxlength: 3
                }
            },
            messages:
            {
                LastName:
                {
                    required: "Last Name is required",
                    maxlength: "Last Name should be 50 charcter"
                },
                Age:
                {
                    required: "Age is required",
                    maxlength: "Age should be 3 digits"
                },
                FavoriteSubject:
                {
                    required: "Please Select Favorite Subject",
                },
                MathsMark:
                {
                    required: "Maths Mark is required",
                    maxlength: "Maths Mark should be 3 digits"
                },
                ChemistryMark:
                {
                    required: "Chemistry Mark is required",
                    maxlength: "Chemistry Mark should be 3 digits"
                },
                ComputerScienceMark:
                {
                    required: "Computer Science Mark is required",
                    maxlength: "Computer Science Mark should be 3 digits"
                }
            }
        });

    });
       
        