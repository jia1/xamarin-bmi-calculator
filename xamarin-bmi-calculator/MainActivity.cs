using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace xamarin_bmi_calculator
{
    [Activity(Label = "@string/Title", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static readonly List<string> bmiHistory = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText heightField = FindViewById<EditText>(Resource.Id.heightInput);
            EditText weightField = FindViewById<EditText>(Resource.Id.weightInput);
            Button calcBtn = FindViewById<Button>(Resource.Id.calcBtn);
            TextView bmiLabel = FindViewById<TextView>(Resource.Id.bmiOutput);
            TextView bmiAdvice = FindViewById<TextView>(Resource.Id.bmiComment);
            Button bmiHistBtn = FindViewById<Button>(Resource.Id.bmiHistBtn);

            calcBtn.Click += (object sender, EventArgs e) => 
            {
                string bmiString = Core.BmiCalculator.Calculate(heightField.Text, weightField.Text);
                bmiString = string.Format("{0:0.00}", bmiString);
                bmiLabel.Text = "Your BMI is " + bmiString;
                if (bmiString.Equals("unavailable because you are naughty!"))
                {
                    bmiAdvice.Text = "I have no advice for the mischievous!";
                }
                else
                {
                    double bmiNumber = double.Parse(bmiString);
                    if (bmiNumber < 18.5)
                        bmiAdvice.Text = "You are underweight! ):";
                    else if (bmiNumber < 25.0)
                        bmiAdvice.Text = "You are healthy! (:";
                    else if (bmiNumber < 30)
                        bmiAdvice.Text = "You are overweight! ):";
                    else
                        bmiAdvice.Text = "You are obese! ):";

                    bmiHistory.Add(bmiString);
                    bmiHistBtn.Enabled = true;
                }
            };

            bmiHistBtn.Click += (sender, e) => 
            {
                var intent = new Intent(this, typeof(BmiHistoryActivity));
                intent.PutStringArrayListExtra("bmi_history", bmiHistory);
                StartActivity(intent);
            };
        }
    }
}

