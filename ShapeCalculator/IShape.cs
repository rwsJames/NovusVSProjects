namespace ShapeCalculator
{
    interface IShape
    {
        // The use of "boundary" and "body" is so that the terms are generalised to include all dimensions
        // "Boundary" = permeter, surface
        // "Body" = area, volume
        double Boundary();
        double Body();
        void PrintDetails();

    }
}
