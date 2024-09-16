db.createView(
   "bookView",
   "BookCollection",
   [ { $project: { "Name": "$BookCollection.Name", numero: 1 } } ]
)

db.bookView.find()