using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace xamarin_bmi_calculator
{
    [Activity(Label = "xamarin_bmi_calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText heightField = FindViewById<EditText>(Resource.Id.heightInput);
            EditText weightField = FindViewById<EditText>(Resource.Id.weightInput);
            Button calcBtn = FindViewById<Button>(Resource.Id.calcBtn);
            TextView bmiLabel = FindViewById<TextView>(Resource.Id.bmiOutput);

            calcBtn.Click += (object sender, EventArgs e) => 
            {
                string bmiString = Core.BmiCalculator.Calculate(heightField.Text, weightField.Text);
                bmiLabel.Text = "Your BMI is: " + bmiString;
            };
        }
    }
}

